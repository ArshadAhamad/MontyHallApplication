import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MontyHallService {
  private apiUrl = 'https://localhost:7134/api/montyhall';

  constructor(private http: HttpClient) {}

  simulateMontyHall(
    numSimulations: number,
    changeDoor: boolean
  ): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/simulate`, {
      numSimulations,
      changeDoor,
    });
  }
}
