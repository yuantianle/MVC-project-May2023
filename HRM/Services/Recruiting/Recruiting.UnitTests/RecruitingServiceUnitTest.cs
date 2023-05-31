using ApplicationCode.Contract.Repositories;
using ApplicationCode.Entities;
using ApplicationCode.Models;
using Infrastructure.Services;
using Moq;
using System.Linq.Expressions;

namespace Recruiting.UnitTests
{
    [TestClass]
    public class RecruitingServiceUnitTest
    {
        private JobService _jobService;

        private static List<Job> _jobs;

        private Mock<IJobRepository> _mockJobRepository;

        // it is called before each test method is executed
        [TestInitialize]
        //[OneTimeSetUp] in nUnit
        public void OneTimeSetup()
        {
             // Arrange
            // 1. Create an instance of JobService [Mock objects]
            // 2. Create an instance of FakeJobRepository [Data]
            // 3. Pass the instance of FakeJobRepository to JobService constructor [Methods]
            _mockJobRepository = new Mock<IJobRepository>(); 
            _jobService = new JobService(_mockJobRepository.Object);
            _mockJobRepository.Setup(x => x.GetAllJobs()).ReturnsAsync(_jobs);           
        }

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {

           _jobs = new List<Job>
            {
                new Job { Id = 1, Title = "Software Developer", Description = "Develop software", StartDate = DateTime.Now, NumberOfPositions = 2 },
                                    
                new Job { Id = 2, Title = "Software Tester", Description = "Test software", StartDate = DateTime.Now, NumberOfPositions = 1 } 
            };
        }


        [TestMethod]
        public async Task TestListOfAllJobsFromFakeData()
        {
            // Set System under Test JobService => GetAllJobs()
            // check the actual output with expected data
            // AAA - Arrange, Act, Assert

            // Arrange
            // 1. Create an instance of JobService [Mock objects]
            // 2. Create an instance of FakeJobRepository [Data]
            // 3. Pass the instance of FakeJobRepository to JobService constructor [Methods]

            //_jobService = new JobService(new MockJobRepository());

            // Act
            var jobs = await _jobService.GetAllJobs();

            // Assert
            Assert.IsNotNull(jobs);
            Assert.AreEqual("Software Developer", jobs[0].Title);
            Assert.IsInstanceOfType(jobs, typeof(List<JobResponseModel>));

        }
    }

    public class MockJobRepository : IJobRepository
    {
        public async Task<List<Job>> GetAllJobs()
        {
            var jobs = new List<Job>
            {
                new Job
                {
                    Id = 1,
                    Title = "Software Developer",
                    Description = "Develop software",
                    StartDate = DateTime.Now,
                    NumberOfPositions = 2
                },
                new Job
                {
                    Id = 2,
                    Title = "Software Tester",
                    Description = "Test software",
                    StartDate = DateTime.Now,
                    NumberOfPositions = 1
                }
            };
            return jobs;
        }
        public async Task<Job> GetJobById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            // this method will get the fake data from the fake repository
            var _somejobs = new List<Job>
            {
                new Job
                {
                    Id = 1,
                    Title = "Software Developer",
                    Description = "Develop software",
                    StartDate = DateTime.Now,
                    NumberOfPositions = 2
                },
                new Job
                {
                    Id = 2,
                    Title = "Software Tester",
                    Description = "Test software",
                    StartDate = DateTime.Now,
                    NumberOfPositions = 1
                }
            };
            return _somejobs;
        }

        public Task<Job> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetExistsAsync(Expression<Func<Job, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Job> AddAsync(Job entity)
        {
            throw new NotImplementedException();
        }

        public Task<Job> UpdateAsync(Job entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}