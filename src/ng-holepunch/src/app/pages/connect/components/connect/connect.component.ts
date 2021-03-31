import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Service, ServiceService, UserService } from 'src/sdk';
import * as signalR from "@microsoft/signalr";
import { debug } from 'node:console';
@Component({
  selector: 'app-connect',
  templateUrl: './connect.component.html',
  styleUrls: ['./connect.component.scss']
})
export class ConnectComponent implements OnInit {
  isAdmin = false;
  showMyServices = false;
  services: Service[] = [];
  static hubConnection: signalR.HubConnection;
  icon = "api";

  statusTitle  = "Connecting To Server";
  statusDesc  = "Please waitting connecting.";

  constructor(
    private _modal: NzModalService,
    private _router: Router,
    private _userService: UserService,
    private _serviceService: ServiceService,
    private _message: NzMessageService) {

    if(!ConnectComponent.hubConnection){
      ConnectComponent.hubConnection = new signalR.HubConnectionBuilder()
        .withUrl('/session',{ accessTokenFactory: () => <string>sessionStorage.getItem('token') })
        .withAutomaticReconnect()
        .build();
    }
  }

  ngOnInit(): void {
    this._userService.isAdmin().subscribe(isAdmin=>{
      this.isAdmin = isAdmin;
    });

    this.startSignalR();
  }

  startSignalR(){


    ConnectComponent.hubConnection
      .start()
      .then(() => {
        this.statusTitle = "Successfully Connected To Server!";
        this.statusDesc = "Please keeping this window.";
        this.icon = 'check-circle';
      })
      .catch(err => {
        this.statusTitle = "Unsuccessfully Connected To Server!";
        this.statusDesc = "Please relogin or check your network.";
        this.icon = "close-circle";
      });
  }

  goToDashboard(){
    this._router.navigateByUrl('/');
  }

  openMyServices(){
    const id = this._message.loading('Loading..', { nzDuration: 0 }).messageId;
    this._serviceService.listMyService().subscribe(services=>{
      this._message.remove(id);
      this.services = services.filter(x=>x.enabled).filter(x=>x.status==='Running');
      this.showMyServices = true;
    })
  }

  logout(){
    this._modal.confirm({
      nzTitle: 'Do you Want to logout?',
      nzContent: 'When clicked the OK button, your connection will dispose.',
      nzOnOk: () =>{
        ConnectComponent.hubConnection.stop().then(()=>{
          sessionStorage.clear();
          this._router.navigateByUrl('/');
        });
      }
    });
  }
}
