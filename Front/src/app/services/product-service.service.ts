import { ClientData } from '../model/client-data';
import { Injectable } from '@angular/core';
import { ApiClientService } from './api-client.service';
import { ProdutoData } from '../model/produto-data';
import { ProductObj } from '../model/product-obj-data';

@Injectable({
    providedIn: 'root'
})
export class ProductServiceService {
    constructor(private http: ApiClientService) { }

    register(data: ProdutoData, jwt: string)
    {
        let obj: ProductObj = {
            data: data,
            jwt: jwt
        }
        this.http.post('produto/cadastro', obj)
            .subscribe()
    }

    initItems()
    {
        var product = this.http.get("produto");
        return product;
    }
}