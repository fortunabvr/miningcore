/*
Copyright 2018 Commercium (cmm.co)
*/

using Autofac;
using AutoMapper;
using MiningCore.Configuration;
using MiningCore.Messaging;
using MiningCore.Notifications;
using MiningCore.Persistence;
using MiningCore.Persistence.Repositories;
using MiningCore.Time;
using Newtonsoft.Json;

namespace MiningCore.Blockchain.Commercium
{
    [CoinMetadata(CoinType.CMM)]
    public class CommerciumPool : CommerciumPoolBase
    {
        public CommerciumPool(IComponentContext ctx,
            JsonSerializerSettings serializerSettings,
            IConnectionFactory cf,
            IStatsRepository statsRepo,
            IMapper mapper,
            IMasterClock clock,
            IMessageBus messageBus) :
            base(ctx, serializerSettings, cf, statsRepo, mapper, clock, messageBus)
        {
        }
    }
}