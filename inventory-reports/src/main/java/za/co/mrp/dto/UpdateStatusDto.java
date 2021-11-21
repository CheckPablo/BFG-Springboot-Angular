/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-10-30 00:15:24
 * @modify date 2020-10-30 00:15:24
 * @desc Request Object containg Updated Status ID
 */
package za.co.mrp.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Pattern;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class UpdateStatusDto {

  @NotNull
  private Long orderId;

  @NotBlank
  @Pattern(regexp = "^(Delivered|Cancelled)$", message = "Delivery staus must be 'Delivered' or 'Cancelled'")
  private String status;

}
