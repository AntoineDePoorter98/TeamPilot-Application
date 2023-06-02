import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestRoutingModule } from './test-routing.module';
import { TestPingLayoutComponent } from './layouts/test-ping-layout/test-ping-layout.component';
import { TestPingComponent } from './pages/test-ping.component';


@NgModule({
  declarations: [
    TestPingLayoutComponent,
    TestPingComponent
  ],
  imports: [
    CommonModule,
    TestRoutingModule
  ]
})
export class TestModule { }
