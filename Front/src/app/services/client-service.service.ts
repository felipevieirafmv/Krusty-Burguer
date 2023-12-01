import { ClientData } from '../model/client-data';
import { Injectable } from '@angular/core';
import { ApiClientService } from './api-client.service';
import { LoginData } from '../model/login-data';

@Injectable({
    providedIn: 'root'
})
export class ClientServiceService {
    constructor(private http: ApiClientService) { }

    register(data: ClientData)
    {
        this.http.post('user/cadastro', data)
            .subscribe(response => console.log(response))
    }

    login(data: LoginData, callback: any)
    {
        this.http.post('user/login', data)
            .subscribe(
                response => {
                    callback(response)
                },
                error => {
                    callback(null)
                })
    }
}