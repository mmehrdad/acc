using Acc.Core.Entities.Accounts;
using Acc.Core.Entities.Persons;
using Acc.Core.Entities.Stores;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class User : IdentityUser<string>
    {

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        
        public ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<Account> AccountCreators { get; set; }
        public virtual ICollection<Account> AccountModifiers { get; set; }

        public virtual ICollection<CostCenter> CostCenterCreators { get; set; }
        public virtual ICollection<CostCenter> CostCenterModifiers { get; set; }

        public virtual ICollection<Document> DocumentCreators { get; set; }
        public virtual ICollection<Document> DocumentModifiers { get; set; }

        public virtual ICollection<DocumentDetail> DocumentDetailCreators { get; set; }
        public virtual ICollection<DocumentDetail> DocumentDetailModifiers { get; set; }

        public virtual ICollection<FinancialPeriod> FinancialPeriodCreators { get; set; }
        public virtual ICollection<FinancialPeriod> FinancialPeriodModifiers { get; set; }

        public virtual ICollection<Cargo> CargoCreators { get; set; }
        public virtual ICollection<Cargo> CargoModifiers { get; set; }

        public virtual ICollection<CargoFactor> CargoFactorCreators { get; set; }
        public virtual ICollection<CargoFactor> CargoFactorModifiers { get; set; }

        public virtual ICollection<CargoSpecific> CargoSpecificCreators { get; set; }
        public virtual ICollection<CargoSpecific> CargoSpecificModifiers { get; set; }

        public virtual ICollection<CargoStore> CargoStoreCreators { get; set; }
        public virtual ICollection<CargoStore> CargoStoreModifiers { get; set; }

        public virtual ICollection<Factor> FactorCreators { get; set; }
        public virtual ICollection<Factor> FactorModifiers { get; set; }

        public virtual ICollection<Specification> SpecificationCreators { get; set; }
        public virtual ICollection<Specification> SpecificationModifiers { get; set; }

        public virtual ICollection<Store> StoreCreators { get; set; }
        public virtual ICollection<Store> StoreModifiers { get; set; }

        public virtual ICollection<CargoLocation> CargoLocationCreators { get; set; }
        public virtual ICollection<CargoLocation> CargoLocationModifiers { get; set; }

        public virtual ICollection<CargoRequest> CargoRequestCreators { get; set; }
        public virtual ICollection<CargoRequest> CargoRequestModifiers { get; set; }
        public virtual ICollection<CargoRequest> CargoRequestApprovers { get; set; }

        public virtual ICollection<CargoRequestItem> CargoRequestItemCreators { get; set; }
        public virtual ICollection<CargoRequestItem> CargoRequestItemModifiers { get; set; }

        public virtual ICollection<Person> PersonCreators { get; set; }
        public virtual ICollection<Person> PersonModifiers { get; set; }

        public virtual ICollection<Department> DepartmentCreators { get; set; }
        public virtual ICollection<Department> DepartmentModifiers { get; set; }

        public virtual ICollection<Transaction> TransactionCreators { get; set; }
        public virtual ICollection<Transaction> TransactionModifiers { get; set; }

        public virtual ICollection<TransactionItem> TransactionItemCreators { get; set; }
        public virtual ICollection<TransactionItem> TransactionItemModifiers { get; set; }

        public virtual ICollection<RoleModule> RoleModuleCreators { get; set; }
        public virtual ICollection<RoleModule> RoleModuleModifiers { get; set; }

        public virtual ICollection<Module> ModuleCreators { get; set; }
        public virtual ICollection<Module> ModuleModifiers { get; set; }

        public virtual ICollection<RoleModulePermission> RoleModulePermissionCreators { get; set; }
        public virtual ICollection<RoleModulePermission> RoleModulePermissionModifiers { get; set; }

        public virtual ICollection<Permission> PermissionCreators { get; set; }
        public virtual ICollection<Permission> PermissionModifiers { get; set; }

    }
}
