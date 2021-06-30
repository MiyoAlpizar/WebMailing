using System;
using System.Linq;
using WebMailing.DataAccess;
using WebMailing.Models.Entities;
using Xunit;

namespace WebMailing.Tests
{
    public class WebMailingShould
    {
        [Fact]
        public void ReturnNewUserWithId1()
        {
            //Arange
            var context = new ApplicationContext();
            var container = new WorkContainer(context);
            var newUser = new User { Email = "test@test.com", FirstName = "Jesse", LastName = "Pinkman" };
            int idExpected = 1;
            //Act
            var user = container.Users.Add(newUser);
            //Assert
            Assert.Equal(idExpected, user.Id);
        }

        [Fact]
        public async void ReturnUsersOrdererByLastNameAndName()
        {
            //Arange
            var context = new ApplicationContext();
            var container = new WorkContainer(context);
            
            var user1 = new User { Email = "test1@test.com", FirstName = "Jesse", LastName = "Pinkman" };
            var user2 = new User { Email = "test2@test.com", FirstName = "Walter", LastName = "White" };
            var user3 = new User { Email = "test3@test.com", FirstName = "Hank", LastName = "Schrader" };
            var user4 = new User { Email = "test4@test.com", FirstName = "Skyler", LastName = "White" };

            int fisrtIdExpected = 4;
            int secondIdExpected = 2;

            //Act
            await container.Users.Add(user1);
            await container.Users.Add(user2);
            await container.Users.Add(user3);
            await container.Users.Add(user4);

            var usersAdded = await container.Users.GetList(x => x.LastName == "White", true, x => x.LastName, x => x.FirstName);
            var users = usersAdded.ToList();
            //Assert
            
            Assert.Equal(fisrtIdExpected, users[0].Id);
            Assert.Equal(secondIdExpected, users[1].Id);
        }
    }
}
