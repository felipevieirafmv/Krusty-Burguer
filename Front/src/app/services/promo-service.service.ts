import { Injectable } from '@angular/core';
import { ClientData } from '../model/client-data';
import { ApiClientService } from './api-client.service';
import { PromoData } from '../model/promo-data';
import { PromoObj } from '../model/promo-obj-data';

@Injectable({
  providedIn: 'root'
})
export class PromoServiceService {
    constructor(private http: ApiClientService) { }

    register(data: PromoData, jwt: string)
    {
        let obj: PromoObj = {
            data: data,
            jwt: jwt
        }
        this.http.post('promocao/cadastro', obj) //trocar rota apos fazer no back
            .subscribe()
    }

    initItems()
    {
        var promo = this.http.get("promocao");
        return promo;
    }
}