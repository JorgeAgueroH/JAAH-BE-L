using Logger.FileSaver;
using NUnit.Framework;

namespace Logger.UnitTests.File
{
    class FileTests
    {
        [Test]
        public void WhenCallingSaveWithANonExistantDirectoryThrowsAnError()
        {
            Log SUT = new Log();
            Assert.Throws<System.IO.DirectoryNotFoundException>(() => SUT.Save(new Model.Log(), "H://DirectoryDoesNotExists", "FileLogger"));
        } 
    }
}
