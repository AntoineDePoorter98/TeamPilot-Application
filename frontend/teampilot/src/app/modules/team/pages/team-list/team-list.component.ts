import { Component } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';

import { TeamDTO } from 'src/app/services/api/v1'; 
import { TeamService } from 'src/app/services/api/v1';
@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.css']
})
export class TeamListComponent {

  teams?: TeamDTO[];
  teamsToShow: TeamDTO[]=[];

  constructor(private service: TeamService){}

  ngOnInit(){this.getTeams()};

  getTeams(){this.service.teamsGet().subscribe(teams => {
    this.teams = teams;
    this.teamsToShow = teams.slice(0,4);
  })};

  change(event:PageEvent){
    const index = event.pageIndex * event.pageSize;
    let total = index+event.pageSize;
    if(total>(this.teams?.length??0)){
      total=this.teams?.length??0}
    this.teamsToShow = this.teams?.slice(index, total)??[];
  }
}
