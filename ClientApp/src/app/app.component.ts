import { Component } from '@angular/core';
import { MontyHallService } from './monty-hall.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title(title: any) {
    throw new Error('Method not implemented.');
  }
  numSimulations: number = 0;
  changeDoor: boolean = false;
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
