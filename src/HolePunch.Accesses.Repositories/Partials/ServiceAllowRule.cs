﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

using domain = HolePunch.Domain;

namespace HolePunch.Accesses.Repositories
{
    public partial class ServiceAllowRule
    {
        public static Expression<Func<ServiceAllowRule, domain.ServiceAllowRule>> GetToDomainExpression()
        {
            return (ef) => new domain.ServiceAllowRule() { Id = ef.Id, ServiceId = ef.ServiceId, Type = ef.Type, ServiceForwardTargetId = ef.ServiceForwardTargetId, Cidr = ef.Cidr, UserId = ef.UserId, CidrGroupId = ef.CidrGroupId, UserGroupId = ef.UserGroupId };
        }

        public static Expression<Func<domain.ServiceAllowRule, ServiceAllowRule>> GetFromDomainExpression()
        {
            return (domain) => new ServiceAllowRule() { Id = domain.Id, ServiceId = domain.ServiceId, Type = domain.Type, ServiceForwardTargetId = domain.ServiceForwardTargetId, Cidr = domain.Cidr, UserId = domain.UserId, CidrGroupId = domain.CidrGroupId, UserGroupId = domain.UserGroupId };
        }

        public static ServiceAllowRule FromDomain(domain.ServiceAllowRule cidrGroup)
        {
            return GetFromDomainExpression().Compile().Invoke(cidrGroup);
        }

        public domain.ServiceAllowRule ToDomain()
        {
            return GetToDomainExpression().Compile().Invoke(this);
        }
    }
}