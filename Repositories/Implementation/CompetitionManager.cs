using Microsoft.EntityFrameworkCore;
using cineVote.Models.Domain;
using Microsoft.AspNetCore.Identity;
using cineVote.Models.DTO;
using Microsoft.Extensions.Options;
using cineVote.Repositories.Abstract;
using System.Security.Claims;
using Newtonsoft.Json;

namespace cineVote.Repositories.Implementation
{
    public class CompetitionManager : ICompetitionManager
    {
        private readonly AppDbContext _db;
        private readonly UserManager<Person> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompetitionManager(AppDbContext db, IHttpContextAccessor httpContextAccessor, UserManager<Person> userManager)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public Task<Status> generateResults(dynamic topNominees, int numberOfParticipants, int competition_id)
        {
            var status = new Status();
            int FirstPlaceId = 0;
            int SecondPlaceId = 0;
            int ThirdPlaceId = 0;

            for (int i = 0; i < Math.Min(topNominees.Count, 3); i++)
            {
                var categoryId = topNominees[i].CategoryId;
                var topNomineeId = topNominees[i].TopNomineeId;

                CategoryNominee categoryNominee = new CategoryNominee()
                {
                    CategoryId = categoryId,
                    NomineeId = topNomineeId
                };
                _db.CategoryNominees.Add(categoryNominee);
                _db.SaveChanges();

                // Assign the IDs to FirstPlaceId, SecondPlaceId, and ThirdPlaceId
                if (i == 0)
                {
                    FirstPlaceId = categoryNominee.CategoryNomineeKey;
                }
                else if (i == 1)
                {
                    SecondPlaceId = categoryNominee.CategoryNomineeKey;
                }
                else if (i == 2)
                {
                    ThirdPlaceId = categoryNominee.CategoryNomineeKey;
                }
            }

            Result results = new Result()
            {
                TotalParticipants = numberOfParticipants,
                FirstPlaceId = FirstPlaceId,
                SecondPlaceId = SecondPlaceId,
                ThirdPlaceId = ThirdPlaceId,
                Competition_Id = competition_id
            };

            _db.Results.Add(results);
            _db.SaveChanges();
            status.StatusCode = 1;
            status.Message = "Results generated successfully";
            return Task.FromResult(status);
        }


        public Task<Status> createCompetition(createCompetitionModel createCompetitionModel)
        {
            var status = new Status();
            int[] nomineeDBIdArray = JsonConvert.DeserializeObject<int[]>(createCompetitionModel.NomineeDBId);
            int[] categoryArray = JsonConvert.DeserializeObject<int[]>(createCompetitionModel.category);

            Competition competition = new Competition()
            {
                Name = createCompetitionModel.Name,
                IsPublic = createCompetitionModel.isPublic,
                StartDate = createCompetitionModel.startDate,
                EndDate = createCompetitionModel.endDate,
                AdminId = getAdminId(),
                Categories = new List<Category>() // Initialize the Categories collection
            };

            _db.Competitions.Add(competition);

            _db.SaveChanges();

            foreach (int categoryId in categoryArray)
            {
                CompetitionCategory competitionCategory = new CompetitionCategory()
                {
                    CategoryId = categoryId,
                    Competition_Id = competition.Competition_Id

                };
                _db.CompetitionCategories.Add(competitionCategory);
            }
            _db.SaveChanges();

            foreach (int nomineeId in nomineeDBIdArray)
            {
                Nominee nominee = new Nominee()
                {
                    TMDBId = nomineeId,
                };
                _db.Nominees.Add(nominee);
                _db.SaveChanges();

                NomineeCompetition nomineeCompetition = new NomineeCompetition()
                {
                    Competition_Id = competition.Competition_Id,
                    NomineeId = nominee.NomineeId
                };

                _db.NomineeCompetitions.Add(nomineeCompetition);
            }

            _db.SaveChanges();

            status.StatusCode = 1;
            status.Message = "Account created successfully";
            return Task.FromResult(status);
        }

        public Task<Competition> getCompetition()
        {
            throw new NotImplementedException();
        }

        public bool removeCompetition(int competitionId)
        {
            try
            {
                var data = this.FindById(competitionId);
                if (data == null)
                    return false;
                _db.Competitions.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Competition competition)
        {
            try
            {
                _db.Competitions.Update(competition);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Competition FindById(int id)
        {
            return _db.Competitions.Find(id);
        }

        private string getAdminId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }


        Task<Competition> ICompetitionManager.getCompetition()
        {
            throw new NotImplementedException();
        }
    }
}
