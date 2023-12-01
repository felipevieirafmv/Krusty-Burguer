import { ClientData } from '../model/client-data';
import { Injectable } from '@angular/core';
import { ApiClientService } from './api-client.service';
import { ProdutoData } from '../model/produto-data';

@Injectable({
    providedIn: 'root'
})
export class ProductServiceService {
    constructor(private http: ApiClientService) { }

    register(data: ProdutoData)
    {
        this.http.post('produto/cadastro', data)
            .subscribe(response => console.log(response))
    }
}