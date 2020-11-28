using AutoWebApi;
using AutoWebApi.Conventions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AutoWebApiSample1.ControllerServices
{
    //[Route("[controller]")]
    [RemoteService]
    public class StudentService: IRemoteService
    {
        public StudentService(IEnumerable<IAutoApiServiceConvention> autoApiServiceConventions = null)
        {
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Student
            {
                Name = "Caine" + index,
                Age = 100 + index
            })
            .ToArray();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
