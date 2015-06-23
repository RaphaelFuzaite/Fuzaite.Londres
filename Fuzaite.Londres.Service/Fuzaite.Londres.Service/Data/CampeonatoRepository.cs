using Fuzaite.Londres.Service.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;

namespace Fuzaite.Londres.Service.Data
{
    public class CampeonatoRepository : ICampeonatoRepository
    {
        private readonly IRedisClient _redisClient;

        public CampeonatoRepository(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public Campeonato Store(Campeonato campeonato)
        {
            using (var rc = _redisClient.As<Campeonato>())
            {
                if (campeonato.Id == default(Guid))
                {
                    campeonato.Id = Guid.NewGuid();
                }
                return rc.Store(campeonato);
            }
        }

        public IList<Models.Campeonato> GetAll()
        {
            using (var rc = _redisClient.As<Campeonato>())
            {
                return rc.GetAll();
            }
        }
    }
}