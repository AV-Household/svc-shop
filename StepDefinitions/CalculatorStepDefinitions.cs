using svc_shop.Controllers;
using svc_shop.Models;

namespace svc_shop.cpecs.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private  List<FamilyMember> familyMembersList = new List<FamilyMember>();
        private  List<Prize> prizesList = new List<Prize>();
        static string userName;

        [Given(@"Семья из")]
        public void GivenFamily(Table FamilyMembersTable)
        {
            var _controller = new WeatherForecastController();
            foreach (var row in FamilyMembersTable.Rows)
            {
                _controller.PostFamily(row[0], row[1], row[2], Convert.ToBoolean(Convert.ToInt32(row[3])));

            }
            familyMembersList = _controller.GetFamily().ToList();
        }

        [Given(@"Список из")]
        public void GivenPrizeList(Table PrizeTable)
        {
            var _controller = new WeatherForecastController();
            foreach (var row in PrizeTable.Rows)
            {
                _controller.PostPrizeList(row[0], row[1], Convert.ToInt32(row[2]));

            }
            prizesList = _controller.GetPrizeList().ToList();
        }

        [Given(@"в систему зашел (.*)")]

        public void GivenAuth(string name)
        {
            userName = name;

        }

        [When(@"Пользователь добавялет (.*)\((.*),(.*)\)")]
        public void WhenUserAddPrize(string name, string description, string cost)
        {
            int temp = Convert.ToInt32(cost);
            if (familyMembersList.Find(member => member.Name == userName).IsAdult == false)
                return;
            else if (prizesList.Find(member => (member.Name == name &&
                                                member.description == description &&
                                                member.cost == temp)) != null)
                return;
            var _controller = new WeatherForecastController();
            _controller.AddPrizeAsync(name, description, temp);
            
        }

        [When(@"Пользователь удаляет (.*)\((.*),(.*)\)")]
        public void WhenUserDeletePrize(string name, string description, string cost)
        {
            int temp = Convert.ToInt32(cost);
            if (familyMembersList.Find(member => member.Name == userName).IsAdult == false)
                return;
            else if (prizesList.Find(member => (member.Name == name &&
                                                member.description == description &&
                                                member.cost == temp)) == null)
                return;
            var _controller = new WeatherForecastController();
            _controller.DeletePrize(name, description, temp);

        }


        [When(@"Пользователь получает список призов")]
        public void WhenPrizesLoaded()
        {
            var _controller = new WeatherForecastController();
            prizesList = _controller.GetPrizeList().ToList();

        }

        [When (@"Пользователь изменяет описание (.*)\((.*)\)")]
        public void WhenUserEditDescription(string name, string description)
        {
            var _controller = new WeatherForecastController();
            if (familyMembersList.Find(member => member.Name == userName).IsAdult == false)
                return;
            else if (prizesList.Find(member => (member.Name == name &&
                                                member.description == description)) == null)
                return;

            _controller.PutPrizeDescription(name, description);
        }

        [Then(@"количество элементов в списке призов (.*)")]
        public void ThenTheResultShouldBe(int count)
        {
            prizesList.Should().HaveCount(count);
        }


        [Then(@"Отчистить список")]
        public void DeletePrizeList()
        {
            var _controller = new WeatherForecastController();
            _controller.DeletePrizeList();
        }


        [Then (@"в списке есть приз (.*)\((.*)\)")]
        public void ThenPrizeExist(string name, string desc)
        {
            var _controller = new WeatherForecastController();
            int temp;
            if (Int32.TryParse(desc, out temp))
                _controller.GetPrizeExist(name, temp);
            else
                _controller.GetPrizeExist(name, desc);

        }

    }
}