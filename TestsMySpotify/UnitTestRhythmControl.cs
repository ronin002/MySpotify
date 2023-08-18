using FakeItEasy;
using MySpotify.Controllers;
using MySpotify.Data.Interfaces;
using MySpotify.Services.Interfaces;

namespace TestsMySpotify
{
    public class UnitTestRhythmControl
    {
        [Fact]
        public void CreateARhythm()
        {
            //Arrange
            var samba = "Samba";
            var fakeRhythmService = A.Fake<IRhythmService>();
            A.CallTo(() => fakeRhythmService.Add(samba)).Return(Task.FromResult());
            var fakeService = A.Fake<IServiceProvider>();
            var sut = new RhythmController(fakeService, fakeRhythmService);
            //Act

            //Assert

        }
    }
}