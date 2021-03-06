﻿using Prizm.Data.DAL.Mill;
using Moq;
using NHibernate.Criterion;
using NUnit.Framework;
using Prizm.Main.Forms;
using Prizm.Main.Forms.ReleaseNote.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Transform;
using Prizm.Domain.Entity.Mill;

namespace Prizm.UnitTests.Forms.Railcar.Search
{
    [TestFixture]
    public class SearchRailcarCommandTest
    {
        [Test]
        public void RailcarSearchTest() 
        {
            var iQuery = new Mock<IQuery>();
            var iSQLQuery = new Mock<ISQLQuery>();
            var notify = new Mock<IUserNotify>();

            Mock<IReleaseNoteRepository> repo = new Mock<IReleaseNoteRepository>();

            var railcars = new List<Prizm.Domain.Entity.Mill.Railcar>();
            {
                new Prizm.Domain.Entity.Mill.Railcar { Number = "Test1" };
                new Prizm.Domain.Entity.Mill.Railcar { Number = "Test2" };
            };


            var viewModel = new ReleaseNoteSearchViewModel(repo.Object, notify.Object);
            viewModel.RailcarNumber = "Test";

            iQuery.Setup(x => x.List<Prizm.Domain.Entity.Mill.Railcar>())
                .Returns(railcars).Verifiable();

            iSQLQuery.Setup(x => x.SetResultTransformer(It.IsAny<IResultTransformer>()))
                .Returns(iQuery.Object).Verifiable();

            repo.Setup(x => x.CreateSQLQuery(It.IsAny<string>()))
                .Returns(iSQLQuery.Object).Verifiable();

            repo.Setup(x => x.SearchReleases(
                It.IsAny<string>(), 
                It.IsAny<DateTime>(), 
                It.IsAny<DateTime>()))
                .Returns(new List<ReleaseNote>() {new ReleaseNote() });

            repo.Setup(x => x.SearchReleasesAllCreteria(
                It.IsAny<string>(), 
                It.IsAny<DateTime>(), 
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                ))
                .Returns(new List<ReleaseNote>() { new ReleaseNote() });

            repo.Setup(x => x.SearchReleasesByRailcar(
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                ))
                .Returns(new List<ReleaseNote>() { new ReleaseNote() });

            var command = new SearchReleaseNoteCommand(viewModel, repo.Object, notify.Object);

            command.Execute();

            repo.Verify(x => x.SearchReleasesByRailcar(
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Times.AtMostOnce());

            repo.Verify(x => x.SearchReleasesAllCreteria(                
                It.IsAny<string>(), 
                It.IsAny<DateTime>(), 
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Times.AtMostOnce());

            repo.Verify(x => x.SearchReleases(
                It.IsAny<string>(), 
                It.IsAny<DateTime>(), 
                It.IsAny<DateTime>()), Times.AtMostOnce());

            Assert.AreEqual(
                repo.Object
                .CreateSQLQuery(It.IsAny<string>())
                .SetResultTransformer(It.IsAny<IResultTransformer>())
                .List<Prizm.Domain.Entity.Mill.Railcar>(), railcars);

        }
    }
}
