import { Component } from '@angular/core';
import { MontyHallService } from './monty-hall.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  numSimulations: number = 0; // Initialize numSimulations
  changeDoor: boolean = false; // Initialize changeDoor
  result: any;

  constructor(private montyHallService: MontyHallService) {}

  simulate(): void {
    this.montyHallService
      .simulateMontyHall(this.numSimulations, this.changeDoor)
      .subscribe(
        (data) => {
          this.result = data;
        },
        (error) => {
          console.error('Error!', error);
        }
      );
  }
}
