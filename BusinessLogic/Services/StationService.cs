﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class StationService: IStationService
    {
        private IUnitOfWork _Database { get; set; }

        public StationService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakeStation(StationDTO stationDto)
        {

            Station station = new Station
            {
                Name= stationDto.Name
            };

            _Database.Stations.Create(station);
            _Database.Save();
        }

        public IEnumerable<StationDTO> GetStations()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Station, StationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Station>, List<StationDTO>>(_Database.Stations.GetAll());
        }

        public StationDTO GetStation(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id станции", "");
            }

            var station = _Database.Stations.Get(id.Value);
            if (station == null)
            {
                throw new ValidationException("станцию не найдено", "");
            }
            return new StationDTO { Id = station.Id, Name = station.Name };
        }

        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
