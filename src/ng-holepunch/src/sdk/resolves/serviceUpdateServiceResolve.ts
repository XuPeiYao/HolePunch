﻿import { Injectable } from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { ServiceService } from '../services';

@Injectable({
  providedIn: 'root'
})
export class ServiceUpdateServiceResolve implements Resolve<any> {

  constructor(private serviceService: ServiceService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.serviceService.updateService(
      route.data.service || route.params.service || route.queryParams.service
    );
  }
}
