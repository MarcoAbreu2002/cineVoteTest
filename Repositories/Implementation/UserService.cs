using cineVote.Models.Domain;
using cineVote.Models.DTO;
using cineVote.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace cineVote.Repositories.Implementation
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<Person> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserService(AppDbContext db, UserManager<Person> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<Status> getProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var userId = getUserId();
            var user = await _db.Users.FindAsync(userId);
            return user ?? throw new InvalidOperationException("User not found.");
        }

        public Task<Status> Vote(string username, int competitionId, int categoryId, int nomineeId, int subscriptionId)
        {
            var status = new Status();
            var userId = getUserId();
            User user = _db.Users.Find(userId);
            Vote vote = new Vote()
            {
                userName = username,
                CategoryId = categoryId,
                NomineeId = nomineeId,
                SubscriptionId = subscriptionId,
                User = user
            };
            _db.Votes.Add(vote);
            _db.SaveChanges();
            VoteSubscription voteSubscription = new VoteSubscription()
            {
                VoteId = vote.VoteId,
                SubscriptionId = subscriptionId
            };
            _db.voteSubscriptions.Add(voteSubscription);
            _db.SaveChanges();
            return Task.FromResult(status);
        }


        private string getUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }

        public bool EditProfile(User user)
        {
            try
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during user update: " + ex.Message);
                return false;
            }
        }
        public Competition FindById(int id)
        {
            return _db.Competitions.Find(id);
        }
        public async Task<Status> Subscribe(string username, int competitionId)
        {
            var status = new Status();
            var userId = getUserId();
            User user = _db.Users.Find(userId);
            var competition = FindById(competitionId);

            try
            {
                var checkSubscription = _db.Subscriptions
                    .FirstOrDefault(cc => cc.userName == username && cc.Competition_Id == competitionId);

                if (checkSubscription == null)
                {
                    Subscription subscription = new Subscription()
                    {
                        Name = competition.Name,
                        Competition_Id = competitionId,
                        userName = user.UserName,
                        User = user
                    };
                    user.SubscriptionId = subscription.SubscriptionId;
                    _db.Users.Update(user);
                    _db.Subscriptions.Add(subscription);
                    await _db.SaveChangesAsync();
                    status.StatusCode = 1;
                    status.Message = "Subscription made successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "You are already subscribed to this competition";
                }
            }
            catch (Exception ex)
            {
                status.StatusCode = -1;
                status.Message = "An error occurred during subscription";
                Console.WriteLine(ex.Message);
            }

            return status;
        }



    }
}
