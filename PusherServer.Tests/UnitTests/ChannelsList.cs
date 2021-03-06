﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Script.Serialization;

namespace PusherServer.Tests.UnitTests
{
    [TestFixture]
    public class When_deserializing_to_a_ChannelsList
    {
        string json = "{\"channels\":" +
                            "{" +
                                "\"test_channel\": {}," +
                                "\"presence-channel\": { \"user_count\": \"300\" } " +
                            "}" +
                       "}";

        [Test]
        public void It_should_make_the_channels_accessible_by_name_via_the_indexer()
        {
            var serializer = new JavaScriptSerializer();
            ChannelsList list = serializer.Deserialize<ChannelsList>(json);

            Assert.IsNotNull(list["test_channel"]);
        }

        [Test]
        public void It_should_be_possible_to_access_channel_information()
        {
            var serializer = new JavaScriptSerializer();
            ChannelsList list = serializer.Deserialize<ChannelsList>(json);

            Assert.AreEqual( list["presence-channel"]["user_count"], "300" );
        }
    }
}
