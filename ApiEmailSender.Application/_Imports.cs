﻿global using ApiEmailSender.Domain.DTOs;
global using MediatR;
global using ApiEmailSender.Application.Interfaces;
global using ApiEmailSender.Infraestructure.Factory.EmailFactories;
global using ApiEmailSender.Application.Commands;
global using ApiEmailSender.Domain.ValueObjects;
global using ApiEmailSender.Application.Factories;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using ApiEmailSender.Domain.Exceptions;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using System.Reflection;
global using Microsoft.ApplicationInsights;