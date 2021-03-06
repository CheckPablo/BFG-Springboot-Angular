/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-10-31 02:31:51
 * @modify date 2020-10-31 02:31:51
 * @desc 
 */
package za.co.mrp.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class UpdateStockRequest {
  private Long rawMaterialId;
  private Double quantity;
}
