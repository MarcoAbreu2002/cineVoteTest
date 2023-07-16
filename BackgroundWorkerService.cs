using cineVote.Models.Domain;
using cineVote.Repositories.Abstract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace cineVote
{
    public class BackgroundWorkerService : BackgroundService
    {
        private int executionCount = 0;

        private readonly ILogger<BackgroundWorkerService> _logger;
        private readonly IServiceProvider _serviceProvider;
        //private readonly CompetitionController _competitionController;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private Timer? _timer;

        public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger, IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            await Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {

                ICompetitionManager CompetitionController = scope.ServiceProvider.GetRequiredService<ICompetitionManager>();

                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                List<Competition> competitions = context.Competitions.ToList();

                DateTime localTime = DateTime.Now;

                foreach (var competition in competitions)
                {
                    if (competition.StartDate < localTime)
                    {
                        if (competition.EndDate > localTime && competition.IsPublic == false)
                        {
                            // Notify the observer
                            CompetitionController.startCompetition(competition);
                            NotifyObserver(competition);
                        }
                        else if (competition.EndDate < localTime && competition.IsPublic == true)
                        {
                            CompetitionController.finishCompetition(competition);
                            NotifyObserver(competition);
                        }
                    }
                }
            }
        }

        private void NotifyObserver(Competition competition)
        {
            _logger.LogInformation("Found this competition: {CompetitionDate}", competition.IsPublic);
        }
    }
}
