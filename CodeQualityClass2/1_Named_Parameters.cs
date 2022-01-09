using System;

namespace CodeQualityClass2
{
    public class NamedParameters
    {
        #region Bad
        
        public void DoSomething1()
        {
            var parser = new FileParser();
            var file = parser.Parse(true, DateTime.Now);
        }

        #endregion

        #region Better
        
        public void DoSomething2()
        {
            var parser = new FileParser();
            var file = parser.Parse(includeMetadata: true, startDate: DateTime.Now);
        } 

        #endregion
    }

    #region Hide
    public class FileParser
    {
        public FileParsingResult Parse(bool includeMetadata, DateTime startDate)
        {
            return default;
        }
    }

    public class FileParsingResult
    {

    }
    #endregion

}
