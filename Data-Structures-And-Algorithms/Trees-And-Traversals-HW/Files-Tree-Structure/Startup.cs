namespace Files_Tree_Structure
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var levelOneFiles = new DigitalFile[5]
            {
                new DigitalFile("FirstFile1", 256),
                new DigitalFile("FirstFile2", 128),
                new DigitalFile("FirstFile3", 512),
                new DigitalFile("FirstFile4", 312),
                new DigitalFile("FirstFile5", 786)
            };

            var levelTwoFiles = new DigitalFile[3]
            {
                new DigitalFile("SecondFile1", 431),
                new DigitalFile("SecondFile2", 128),
                new DigitalFile("SecondFile3", 512)
            };

            var levelThreeFiles = new DigitalFile[3]
            {
                new DigitalFile("ThirdFile2", 1244),
                new DigitalFile("ThirdFile2", 1244),
                new DigitalFile("ThirdFile3", 788)
            };

            var levelTwoFolders = new DigitalFolder[1]
            {
                new DigitalFolder("SecondLevelFolder1", levelThreeFiles, null)
            };

            var levelOneFolders = new DigitalFolder[2]
            {
                new DigitalFolder("FirstLevelFolder1", levelOneFiles, levelTwoFolders),
                new DigitalFolder("FirstLevelFolder2", levelTwoFiles, levelTwoFolders)
            };
        }
    }
}