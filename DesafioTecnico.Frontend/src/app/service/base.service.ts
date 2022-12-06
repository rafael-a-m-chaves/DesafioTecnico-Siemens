import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import EstrutucAwaitResponse from '../controls/EstrutucAwaitResponse';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  private readonly serviceURL: string;

	constructor(private http: HttpClient) {
		this.serviceURL = environment.serviceURL;
	}

	get(endPoint: string) : Observable<EstrutucAwaitResponse> {
		return this.http.get<any>(this.serviceURL + endPoint);
	}

	post(endPoint: string, data: any) : Observable<EstrutucAwaitResponse> {
		let body = JSON.stringify(data);
		return this.http.post<any>(this.serviceURL + endPoint, body);
	}

	delete(endPoint: string) : Observable<EstrutucAwaitResponse> {
		return this.http.delete<any>(this.serviceURL + endPoint);
	}

	put(endPoint: string, data: any) : Observable<EstrutucAwaitResponse> {
		let body = JSON.stringify(data);
		return this.http.post<any>(this.serviceURL + endPoint, body);
	}
}
