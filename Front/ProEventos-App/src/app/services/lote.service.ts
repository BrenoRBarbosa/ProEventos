import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Evento } from '@app/models/Evento';
import { Lote } from '@app/models/Lote';
import { Observable } from 'rxjs/internal/Observable';
import { take } from 'rxjs/internal/operators/take';

@Injectable(
  //{providedIn: 'root'}
  )
export class LoteService {

  constructor(private http: HttpClient) { }

  baseURL = 'https://localhost:5001/api/lotes'

  public getLoteByEventoId(eventoId: number): Observable<Lote[]> {
    return this.http.get<Lote[]>(`${this.baseURL}/${eventoId}`).pipe(take(1));
  }

  public saveLote(eventoId: number, lotes: Lote[]): Observable<Lote[]> {
    return this.http.put<Lote[]>(`${this.baseURL}/${eventoId}`, lotes).pipe(take(1));
  }

  public deleteLote(eventoId: number, loteId: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${eventoId}/${loteId}`).pipe(take(1));
  }

}
