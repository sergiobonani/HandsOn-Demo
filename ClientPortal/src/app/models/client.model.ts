import { AddressClient } from './address-client.model';

export class Client{
    id: string;
    name: string;
    dateOfBirth: string;
    address: AddressClient;
    constructor(){
        this.address = new AddressClient();
    }
    // gender: string;
    // zipCode: string;
    // address: string;
    // addressNumber: string;
    // complement: string;
    // district: string;
    // state: string;
    // city: string;
    // country: string;
}