import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Apiservice } from 'src/app/core/services/apiservice.service';
import { ContactMaster } from './contact';
import { map } from 'rxjs/operators';

@Injectable()
export class Contactservice {
  private readonly ContactController = "Contact";
  constructor(private apiService: Apiservice) { }



  addContact(contactMaster: ContactMaster): Observable<ContactMaster> {
    return this.apiService.POST(this.ContactController, contactMaster).pipe(map((res: any) => {
      return <ContactMaster>res;
    }));
  }

  UpdateContact(contactMaster: ContactMaster): Observable<ContactMaster> {
    return this.apiService.PUT(this.ContactController+ "/" + contactMaster.ContactId, contactMaster).pipe(map((res: any) => {
      return <ContactMaster>res;
    }));
  }

  deleteContact(contactId: number): Observable<boolean> {
    return this.apiService.Delete(this.ContactController + "/" + contactId).pipe(map((res: any) => {
      return <boolean>res;
    }));
  }

  getContact(contactId: number): Observable<ContactMaster> {
    return this.apiService.GET(this.ContactController + "/" + contactId).pipe(map((res: any) => {
      return <ContactMaster>res;
    }));
  }

  getALLContact(): Observable<ContactMaster[]> {
    return this.apiService.GET(this.ContactController).pipe(map((res: any) => {
      return <ContactMaster[]>res;
    }));
  }
}
