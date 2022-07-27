using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelo de Municipio")]
        public void E_Possivel_Mapear_os_Modelos_Municipio()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var userDto = Mapper.Map<MunicipioDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Nome, entity.Nome);
            Assert.Equal(userDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDto.UfId, entity.UfId);

            var userDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(userDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(userDtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(userDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(userDtoCompleto.UfId, listaEntity.FirstOrDefault().UfId);
            Assert.NotNull(userDtoCompleto.Uf);

            var listaDto = Mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listaDto[i].UfId, listaEntity[i].UfId);
            }

            var userDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(userDtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoCreateResult.UfId, entity.UfId);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);

            var userDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(userDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoCreateResult.UfId, entity.UfId);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto para Model
            var userModel = Mapper.Map<MunicipioModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Nome, userDto.Nome);
            Assert.Equal(userModel.CodIBGE, userDto.CodIBGE);
            Assert.Equal(userModel.UfId, userDto.UfId);

            var userDtoCreate = Mapper.Map<MunicipioDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Nome, userModel.Nome);
            Assert.Equal(userDtoCreate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoCreate.UfId, userModel.UfId);

            var userDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Nome, userModel.Nome);
            Assert.Equal(userDtoUpdate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoUpdate.UfId, userModel.UfId);

        }
    }
}
