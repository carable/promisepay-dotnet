﻿using Newtonsoft.Json;
using Xunit;
using PromisePayDotNet.Dto;
using PromisePayDotNet.Implementations;
using PromisePayDotNet.Internals;

namespace PromisePayDotNet.Tests
{
    public class UploadTest
    {
        [Fact]
        public void UploadDeserialization()
        {
            const string jsonStr = "{ \"id\": \"a2711d90-ed41-4d12-81d2-000000000002\", \"processed_lines\": 6, \"total_lines\": 6, \"update_lines\": 0, \"error_lines\": 6, \"progress\": 100.0 }";
            var upload = JsonConvert.DeserializeObject<Upload>(jsonStr);
            Assert.NotNull(upload);
            Assert.Equal("a2711d90-ed41-4d12-81d2-000000000002", upload.Id);
        }

        //[Fact]
        //[Ignore("Not implemented yet")]
        public void CreateUploadSuccessfully()
        {
            throw new System.Exception();
        }

        //[Fact]
        //[Ignore("Not implemented yet")]
        public void ListUploadsSuccessfully()
        {
            throw new System.Exception();
        }

        //[Fact]
        //[Ignore("Not implemented yet")]
        public void GetUploadByIdSuccessfully()
        {
            throw new System.Exception();
        }



        //[Fact]
        //[Ignore("Not implemented yet")]
        public void GetStatusSuccessfully()
        {
            throw new System.Exception();            
        }

        //[Fact]
        //[Ignore("Not implemented yet")]
        public void StartImportSuccessfully()
        {
            throw new System.Exception();            
        }


    }
}
