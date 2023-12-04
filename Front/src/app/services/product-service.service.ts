import { ClientData } from '../model/client-data';
import { Injectable } from '@angular/core';
import { ApiClientService } from './api-client.service';
import { ProdutoData } from '../model/produto-data';
import { productObj } from '../model/product-obj-data';

@Injectable({
    providedIn: 'root'
})
export class ProductServiceService {
    constructor(private http: ApiClientService) { }

    register(data: ProdutoData, jwt: string)
    {
        let obj: productObj = {
            data: data,
            jwt: jwt
        }
        this.http.post('produto/cadastro', obj)
            .subscribe()
    }
}