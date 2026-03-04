using Xunit;

namespace TaskManagementApi.Tests;

public class UnitTest1
{
    [Fact]
    public void PassingTest()
    {
        Assert.True(true);
    }

    [Fact]
    public void FailingTest_ForDemo()
    {
        Assert.Equal(2, 1 + 1);   // will pass
    }
}
