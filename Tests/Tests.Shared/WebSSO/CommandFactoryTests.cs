﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Sustainsys.Saml2.WebSso;

namespace Sustainsys.Saml2.Tests.WebSso
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void CommandFactory_GetCommand_Invalid_ReturnsNotFound()
        {
            new CommandFactory().GetCommand("Invalid").Should().BeOfType<NotFoundCommand>();
        }

        [TestMethod]
        public void CommandFactory_GetCommand_SignIn_ReturnsSignIn()
        {
            new CommandFactory().GetCommand("SignIn").Should().BeOfType<SignInCommand>();
        }

        [TestMethod]
        public void CommandFactory_GetCommand_IsCaseInsensitive()
        {
          new CommandFactory().GetCommand("signin").Should().BeOfType<SignInCommand>();
        }

        [TestMethod]
        public void CommandFactory_GetCommand_Acs_ReturnsAcs()
        {
            new CommandFactory().GetCommand("Acs").Should().BeOfType<AcsCommand>();
        }

        [TestMethod]
        public void CommandFactory_GetCommand_Root_ReturnsMetadata()
        {
            new CommandFactory().GetCommand("").Should().BeOfType<MetadataCommand>();
        }

        [TestMethod]
        public void CommnandFactory_GetCommand_StripsOffLeadingSlash()
        {
            new CommandFactory().GetCommand("/Acs").Should().BeOfType<AcsCommand>();
        }

        [TestMethod]
        public void CommandFactory_GetCommand_SignOut_ReturnsSignOut()
        {
            new CommandFactory().GetCommand("Logout").Should().BeOfType<LogoutCommand>();
        }

        [TestMethod]
        public void CommandFactory_GetCommand_NullCheckCommandName()
        {
            Action a = () => new CommandFactory().GetCommand(null);

            a.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("commandName");
        }
    }
}
