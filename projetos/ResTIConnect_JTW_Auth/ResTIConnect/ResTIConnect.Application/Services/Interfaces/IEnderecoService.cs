﻿using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.Services.Interfaces;

public interface IEnderecoService : IBaseService<NewEnderecoInputModel, EnderecoViewModel, Endereco>
{
}
