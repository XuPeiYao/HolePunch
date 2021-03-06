import { ServiceListServiceForwardTargetResolve } from './../../../../../sdk/resolves/serviceListServiceForwardTargetResolve';
import { ServiceListServiceAllowRuleResolve } from './../../../../../sdk/resolves/serviceListServiceAllowRuleResolve';
import { NgModule } from '@angular/core';
import { RouteReuseStrategy, RouterModule, Routes } from '@angular/router';
import { ServiceGetServiceResolve, UserListUserGroupResolve, UserListUserResolve } from 'src/sdk';
import { EditServiceComponent } from './components/edit-service/edit-service.component';
import { ServiceManageComponent } from './components/service-manage/service-manage.component';

const routes: Routes = [
  { path:'',redirectTo:'list' },
  {
    path:'list',
    pathMatch: 'full',
    component:ServiceManageComponent
  },
  {
    path: 'create-service',
    component: EditServiceComponent,
    data:{
      isNew: true
    },
  },
  {
    path: 'edit-service/:serviceId',
    component: EditServiceComponent,
    data:{
      isNew: false
    },
    resolve:{
      service: ServiceGetServiceResolve,
      allowRules: ServiceListServiceAllowRuleResolve,
      targets: ServiceListServiceForwardTargetResolve,
      users: UserListUserResolve,
      userGroups: UserListUserGroupResolve
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
  ]
})
export class ServiceManageRoutingModule { }
