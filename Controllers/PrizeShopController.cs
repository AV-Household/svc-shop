using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc_shop.Models;
using System.Collections.Generic;
using System.Globalization;

namespace svc_shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PrizeShopController : ControllerBase
    {
        private static List<FamilyMember> familyMembersList = new List<FamilyMember>();
        private static List<Prize> prizesList = new List<Prize>();


        [HttpGet("GetFamily")]
        public IEnumerable<FamilyMember> GetFamily()
        {
            return familyMembersList;
        }

        [HttpGet("GetPrizeList")]

        public IEnumerable<Prize> GetPrizeList()
        {
            return prizesList;
        }

        [HttpPost("AddPrizeAsync")]
        public void AddPrizeAsync(string name, string description, int cost)
        {
            prizesList.Add(new Prize
                (
                Guid.Empty,
                name,
                description,
                cost
                ));

        }

        [HttpPost("PostFamily")]
        public void PostFamily(string name, string phone, string email, bool isAdult)
        {
            familyMembersList.Add( new FamilyMember
                (
                Guid.NewGuid(),
                name,
                phone,
                email,
                isAdult
                ));
        }

        [HttpPost("PostPrizeList")]
        public void PostPrizeList(string name, string description, int cost)
        {
            prizesList.Add(new Prize
                (
                Guid.NewGuid(),
                name,
                description,
                cost
                ));
        }

        [HttpDelete("DeletePrizeList")]
        public void DeletePrizeList()
        {
            prizesList.Clear();
        }

        [HttpDelete("DeletePrize")]
        public void DeletePrize(string name, string description, int cost)
        {
            prizesList.Remove(prizesList.Find(member => (
                                                member.Name == name &&
                                                member.description == description &&
                                                member.cost == cost)));

        }

        [HttpPut("PatchPrizeDescription")]
        public void PutPrizeDescription(string name, string description)
        {
            int tempCost = prizesList.Find(member => member.Name == name).cost;
            string tempDescriprion = prizesList.Find(member => member.Name == name).description;
            DeletePrize(name, tempDescriprion, tempCost);
            AddPrizeAsync(name,description,tempCost);
        }

        [HttpGet("PrizeExistDescription")]
        public bool GetPrizeExist(string name,string desc)
        {
            if (prizesList.Find(member => (member.Name == name && member.description == desc)) != null)
                return true;
            else return false;

        }
        [HttpGet("PrizeExistCost")]
        public bool GetPrizeExist(string name, int cost)
        {
            if (prizesList.Find(member => (member.Name == name && member.cost == cost)) != null)
                return true;
            else return false;

        }

    }
}