using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using Xunit;
using Moq;

namespace PizzaBox.Testing.Specs
{
  public class UserSpec {
    // AudioFactory af = new AudioFactory();
    // VideoFactory vf = new VideoFactory();
    // Mock<AMedia> mock;
    Mock<User> mock;

    public UserSpec()
    {
      mock = new Mock<User>();
      mock.Setup(am => am.CanChangeStore()).Returns(false);
    }

    [Fact]          // call before the execution Test_AudioObject, log the test (listen 104.3 FM)
    public void Test_UserObject()
    {
      // arrange
      // var sut = af;
      // var expected = typeof(Song);

      // // act
      // AMedia actual = af.Create<Song>();

      // assert
      Assert.True(false == false);
    }

    // public void Test_VideoPlay()
    // {
    //   var sut = MediaPlayerSingleton.Instance;
    //   var mm = mock.Object;

    //   // mm.Duration = new System.TimeSpan(1, 0, 0);

    //   // Assert.False(mm.Play());
    //   // Assert.True(sut.Execute(mm.Play, mm));


    // }
  }
}
