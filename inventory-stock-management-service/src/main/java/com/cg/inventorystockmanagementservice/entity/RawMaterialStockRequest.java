/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-10-31 01:43:30
 * @modify date 2020-10-31 01:43:30
 * @desc [description]
 */
package com.cg.inventorystockmanagementservice.entity;

import javax.validation.constraints.DecimalMax;
import javax.validation.constraints.NotNull;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class RawMaterialStockRequest {

  @NotNull
  private Long rawMaterialId;
  @NotNull
  @DecimalMax(value = "999.99")
  private Double quantity;

}
