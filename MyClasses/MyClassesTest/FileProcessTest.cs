using MyClasses;


namespace MyClassesTest
{
    public class FileProcessTest
    {
        [Fact]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\Regedit.exe");

            Assert.True(fromCall);
        }

        [Fact]
        public void FileNameDoesNotExist()
        {

            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\Regedit.exeeee");

            Assert.False(fromCall);
        }

        [Fact]
        public void FileNameIsNullOrEmpty()
        {
        }

        [Fact]
        public void FileNameIsNullOrEmptyTryCatch()
        {
        }


    }
}
