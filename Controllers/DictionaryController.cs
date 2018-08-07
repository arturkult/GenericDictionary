using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionaries.Repositories;
using Dictionaries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dictionaries.Repositories.Interfaces;

namespace Dictionaries.Controllers
{
    [Produces("application/json")]
    [Route("api/Dictionary")]
    public class DictionaryController : Controller
    {
        readonly IDictionaryRepository repository;

        public DictionaryController(IDictionaryRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public object Get(string DictionaryName)
        {
            var DictList = repository.GetProperDictionaryByName(DictionaryName);
            return DictList;
        }
    }
}