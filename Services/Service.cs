﻿using System.Linq.Expressions;
using Angel_Paredes_P2_AP1.Models;

public class Services
{
    public async Task<bool> Guardar(Modelo modelo)
    {
        return true;
    }

    public async Task<bool> Existe(int Id)
    {
        return true;
    }

    public async Task<bool> Insertar(Modelo modelo)
    {
        return true;
    }

    public async Task<bool> Eliminar(int id)
    {
        return true;
    }

    public async Task<bool> Modificar(Modelo modelo)
    {
        return true;
    }

    public async Task<Modelo?> Buscar(int id)
    {
        return new Modelo();
    }

    public async Task<List<Modelo>> Listar(Expression<Func<Modelo, bool>> criterio)
    {
        return new List<Modelo>();
    }

}