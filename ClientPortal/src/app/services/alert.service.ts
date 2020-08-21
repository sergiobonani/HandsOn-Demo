import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class AlertService{
    constructor(private toasterService: ToastrService) {
        
    }

    showStickyMessage(messageError: string, severity: MessageSeverity, error?: any){
        if (error && error.error instanceof Array)
        {
            for (let errorMessage of error.error)
            {
              var msgObject = { firstPart: "" };

              if(errorMessage.errorMessage != undefined){
                  msgObject = this.splitInTwo(errorMessage.errorMessage);                        
              }else{
                  msgObject = this.splitInTwo(errorMessage.constraints.isNotEmpty);
              }                
              this.showMessage(msgObject.firstPart, severity);
            }

            return;
        }else{
            this.showMessage(messageError, severity);
        }
    }

    private showMessage(msg: string, severity: MessageSeverity){
        switch (severity) {
            case MessageSeverity.error:
                this.toasterService.error(msg);
                break;
            case MessageSeverity.success:
            this.toasterService.success(msg);
                break;        
            default:
                break;
        }
    }

    splitInTwo(text: string): { firstPart: string, secondPart: string } {
        
        return { firstPart: text, secondPart: null };

        // let part1 = text.substr(0, separatorIndex).trim();
        // let part2 = text.substr(separatorIndex + 1).trim();

        // return { firstPart: part1, secondPart: part2 };
    }
}

export enum MessageSeverity
{
    default,
    info,
    success,
    error,
    warn,
    wait
}