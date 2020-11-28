using AutoWebApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoWebApiSample1.ControllerServices
{
    [Route("[controller]")]
    [RemoteService]
    public class StudentService: IRemoteService
    {
        public StudentService() { }

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
