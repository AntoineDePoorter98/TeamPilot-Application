import { Component, NgModule } from '@angular/core';

import { PingService } from 'src/app/services/api/v1/';
import { PingDTO } from 'src/app/services/api/v1';

@Component({
  selector: 'app-test-ping',
  templateUrl: './test-ping.component.html',
  styleUrls: ['./test-ping.component.css']
})
export class TestPingComponent {

  ping: PingDTO={pingResponse:''}

  constructor(private service:PingService){}

  getPing(){this.service.testsGet().subscribe(ping=> this.ping=ping);
  }
}
