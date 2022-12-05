import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  private readonly serviceURL: string;

	constructor(private http: HttpClient) {
		this.serviceURL = environment.serviceURL;
	}

	get(endPoint: string) {
		return this.http.get<any>(this.serviceURL + endPoint);
	}

	post(endPoint: string, data: any) {
		let body = JSON.stringify(data);

		return this.http.post<any>(this.serviceURL + endPoint, body);
	}
}
