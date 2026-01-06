using System;
using System.Collections.Generic;

namespace FireAndBlood.SOLID
{
    //Westeros Mental Model
    // in Westeros, each house has its own responsibilities and duties.
    // The Single Responsibility Principle (SRP) states that a class should have only one reason to change.
    public interface IBattleReportGenerator
    {
        string Generate();
    }
    public interface IReportRepository
    {
        void Save(string report);
    }

    public interface IMessageSender
    {
        void Send(string message);
    }

    public class BattleReportGenerator : IBattleReportGenerator
    {
        public string Generate()
        {
            // Logic to generate battle report
            return "Battle Report Content";
        }
    }

    public class ReportRepository : IReportRepository
    {
        public void Save(string report)
        {
            // Logic to save report to database or file
            Console.WriteLine("Report saved: " + report);
        }
    }

    public class RavenMessenger : IMessageSender
    {
        public void Send(string message)
        {
            // Logic to send message via raven
            Console.WriteLine("Raven sent with message: " + message);
        }
    }

    public class BattleReportService
    {
        private readonly IBattleReportGenerator _reportGenerator;
        private readonly IReportRepository _reportRepository;
        private readonly IMessageSender _messageSender;

        public BattleReportService(IBattleReportGenerator reportGenerator, IReportRepository reportRepository, IMessageSender messageSender)
        {
            _reportGenerator = reportGenerator;
            _reportRepository = reportRepository;
            _messageSender = messageSender;
        }

        public void CreateAndDistributeReport()
        {
            var report = _reportGenerator.Generate();
            _reportRepository.Save(report);
            _messageSender.Send(report);
        }
    }
}