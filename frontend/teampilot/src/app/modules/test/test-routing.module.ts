import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestPingComponent } from './pages/test-ping.component';
import { TestPingLayoutComponent } from './layouts/test-ping-layout/test-ping-layout.component';

const routes: Routes = [{path:'',
component:TestPingLayoutComponent,
children:[{path:'',
 component:TestPingComponent
}]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TestRoutingModule { }
