using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
using static System.Formats.Asn1.AsnWriter;

namespace ShubkivTour.Services
{
    public class TourReviewsSender : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;


        public TourReviewsSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();

                    var today = DateTime.Now.AddDays(2);
                    //var today = DateTime.Now;

                    var endedTours = dbContext.Tours
                        .Include(t => t.TourClients)
                            .ThenInclude(tc => tc.Client)
                        .Where(t => t.EndDate.Date.Day == today.Day && t.ReviewSent != true)
                        .ToList();

                    foreach (var tour in endedTours)
                    {
                        foreach (var member in tour.TourClients)
                        {
                            await emailSender.SendEmailAsync(member.Client.Email, "Відгук до туру",
                                $"<h1>Шановний {member.Client.Name},</h1>" +
                                $"<p>Ми надіємось вам сподобався тур: {tour.Name}.</p>" +
                                "<p>Ми будемо вдячні якщо ви знайдете час і залишите відгук.</p>" +
                                $"<a href='https://localhost:7026/Tour/AddTourReview/{tour.Id}'>Залишити відгук</a>" +
                                "<p>Дякуємо!</p>");
                        }
                        tour.ReviewSent = true;
                    }
                    dbContext.SaveChanges();
                    //_context.SaveChanges();
                }
                //await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(120), stoppingToken);

            }
        }
    }
}
