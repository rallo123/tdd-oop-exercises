using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;

namespace TestTools.Unit
{
    // based on IFileSystem
    public class TestFileSystem
    {
        public void Act(Action<IFileSystem> action)
        {
            throw new NotImplementedException();
        }

        public AssertObject FileAssert { get; }

        public class AssertObject
        {
            // State of file systems
            public void FileExists(string path)
            {
                throw new NotImplementedException();
            }

            public void FileDoesNotExist(string path)
            {
                throw new NotImplementedException();
            }

            public void DirectoryExist(string path)
            {
                throw new NotImplementedException();
            }

            public void DirectoryDoesNotExist(string path)
            {
                throw new NotImplementedException();
            }

            // Mutatation in file systems
            public void FileCreated(string path)
            {
                throw new NotImplementedException();
            }

            public void FileDeleted(string path)
            {
                throw new NotImplementedException();
            }

            public void Created(string path)
            {
                throw new NotImplementedException();
            }

            public void Deleted(string path)
            {
                throw new NotImplementedException();
            }
        }
    }
}
