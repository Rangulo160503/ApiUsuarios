using ApiUsuarios.BLL.Dtos;
using ApiUsuarios.DLL.Entidades;
using ApiUsuarios.DLL.Repositorio;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.BLL.Servicios
{
    public class VehiculosServicio : IVehiculosServicio
    {
        // Inyección de dependencias
        private readonly IVehiculosRepositorio _vehiculosRepositorio;
        private readonly IMapper _mapper;

        public VehiculosServicio(IVehiculosRepositorio vehiculosRepositorio, IMapper mapper)
        {
            _vehiculosRepositorio = vehiculosRepositorio;
            _mapper = mapper;
        }

        public async Task<CustomResponse<VehiculoDto>> ActualizarVehiculoAsync(VehiculoDto vehiculoDto)
        {
            var respuesta = new CustomResponse<VehiculoDto>();

            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDto);

            if (!await _vehiculosRepositorio.ActualizarVehiculoAsync(vehiculo))
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se pudo actualizar el vehículo";
                return respuesta;
            }

            return respuesta;
        }

        public async Task<CustomResponse<VehiculoDto>> EliminarVehiculoAsync(int id)
        {
            var respuesta = new CustomResponse<VehiculoDto>();

            if (!await _vehiculosRepositorio.EliminarVehiculoAsync(id))
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se pudo eliminar el vehículo";
                return respuesta;
            }

            return respuesta;
        }

        public async Task<CustomResponse<VehiculoDto>> AgregarVehiculoAsync(VehiculoDto vehiculoDto)
        {
            var respuesta = new CustomResponse<VehiculoDto>();

            // Validaciones de negocio
            if (vehiculoDto.Anno < 1950)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se permiten vehículos con año menor a 1950";
                return respuesta;
            }

            if (vehiculoDto.Precio <= 0)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "El precio del vehículo debe ser mayor a 0";
                return respuesta;
            }

            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDto);

            if (!await _vehiculosRepositorio.AgregarVehiculoAsync(vehiculo))
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se pudo agregar el vehículo";
                return respuesta;
            }

            return respuesta;
        }

        public async Task<CustomResponse<VehiculoDto>> ObtenerVehiculoPorIdAsync(int id)
        {
            var respuesta = new CustomResponse<VehiculoDto>();

            var vehiculo = await _vehiculosRepositorio.ObtenerVehiculoPorIdAsync(id);

            respuesta.Data = _mapper.Map<VehiculoDto>(vehiculo);

            return respuesta;
        }

        public async Task<CustomResponse<List<VehiculoDto>>> ObtenerVehiculosAsync()
        {
            var respuesta = new CustomResponse<List<VehiculoDto>>();

            var vehiculos = await _vehiculosRepositorio.ObtenerVehiculosAsync();

            respuesta.Data = _mapper.Map<List<VehiculoDto>>(vehiculos);

            return respuesta;
        }
    }
}
